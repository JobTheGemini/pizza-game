import React from 'react';

interface IProps {
    winner: string;
}

export const EndGameComponent: React.FC<IProps>  = ({ winner }: IProps) =>
    <h1>The winner is: Player {winner}</h1>
