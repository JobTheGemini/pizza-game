import React from 'react';

interface IProps {
    doStartGame(): Promise<void>;
}

export const NewGameComponent: React.FC<IProps>  = ({ doStartGame }: IProps) => 
    <div className={'form-group'}>
        <button className={'btn btn-primary'} onClick={() => doStartGame()}>Start a new game</button>
    </div>
