import React, {ChangeEvent, useState} from 'react';
import IGameStatus from '../interfaces/IGameStatus';

interface IProps {
    gameStatus: IGameStatus;
    doConfirmAction(pizzas: number): void;
}

export const GameActionComponent: React.FC<IProps>  = ({ gameStatus, doConfirmAction }: IProps) =>   {

    const [pizzas, setPizzas] = useState<number>(0);
    
    const doSetPizzas = (e: ChangeEvent<HTMLInputElement>) =>  {
        try  {
            const pizzasValue = parseInt(e.target.value);
            if (!isNaN(pizzasValue))
                setPizzas(pizzasValue);
            else
                setPizzas(0);
        }
        catch
        {
            setPizzas(0);
        }
    }

    return <div className={'row'}>
        <div className={'col-3'}>
            <ul className={'list-group'}>
                <li className={'list-group-item disabled'}>Players</li>
                <li className={gameStatus.NextPlayer === 'A' ? 'list-group-item list-group-item-success' : 'list-group-item'}>Player A</li>
                <li className={gameStatus.NextPlayer === 'B' ? 'list-group-item list-group-item-success' : 'list-group-item'}>Player B</li>
            </ul>
        </div>
        <div className={'col-9'}>
            <div className={'alert alert-info '}>
                <div>There are only <b>{gameStatus.Pizzas}</b> pizzas on the table.</div>
                {gameStatus.LastAction > 0 && <div><b>Last action: </b>{gameStatus.LastAction} pizza(s) eaten.</div>}
            </div>
            <div className={'row g-3 align-items-center"'}>
                <div className={'col-auto'}>
                    <label className={'col-form-label fw-bold'}>How many pizzas do you want to eat?:</label>
                </div>
                <div className={'col-auto'}>
                    <input className={'form-control text-end col-s-2'} type={'text'} value={pizzas} onChange={doSetPizzas} />
                </div>
                <div className={'col-auto'}>
                    <button className={'btn btn-primary'} onClick={() => doConfirmAction(pizzas)}>Confirm</button>
                </div>
            </div>
        </div>
    </div>;

}