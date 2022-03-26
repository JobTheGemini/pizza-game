import React, { useState } from 'react';
import * as signalR from '@microsoft/signalr';
import IGameStatus from '../interfaces/IGameStatus';
import { NewGameComponent } from './NewGameComponent';
import { EndGameComponent } from './EndGameComponent';
import { GameActionComponent } from './GameActionComponent';
import { ErrorComponent } from './ErrorComponent';

interface IProps {
    hubConnection: signalR.HubConnection;
}

export const GameComponent: React.FC<IProps> = ({ hubConnection}: IProps) => {

    const defaultGameStatus: IGameStatus = {
        Winner: '',
        Pizzas: 0,
        LastAction: 0,
        IsEnded: true,
        NextPlayer: ''
    };
    
    const [gameStatus, setGameStatus] = useState<IGameStatus>(defaultGameStatus);
    const [error, setError] = useState<string>('');

    hubConnection.on("GameUpdate", message => {
        setGameStatus(JSON.parse(message));
    });
    hubConnection.on("Error", message => {
        setError(message);
        setTimeout(() => setError(''), 3000);
    });

    const startGame = async () => {
        await hubConnection.invoke('startMessage');
    }

    const confirmAction = async (pizzas: number) => {
        await hubConnection.invoke('ActionMessage', pizzas);
    }

    if (!gameStatus)
    {
        return <NewGameComponent doStartGame={startGame} />
    }
    
    return <div>
        {error && <ErrorComponent error={error} />}
        {!gameStatus.IsEnded && <GameActionComponent gameStatus={gameStatus} doConfirmAction={confirmAction} />}
        {gameStatus.IsEnded && gameStatus.Winner && <EndGameComponent winner={gameStatus.Winner} />}
        {gameStatus.IsEnded && <NewGameComponent doStartGame={startGame} />}
    </div>;
};