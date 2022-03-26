import React from 'react';

interface IProps {
    error: string;
}

export const ErrorComponent: React.FC<IProps>  = ({ error }: IProps) =>
    <div className={'alert alert-danger'}>{error}</div>
