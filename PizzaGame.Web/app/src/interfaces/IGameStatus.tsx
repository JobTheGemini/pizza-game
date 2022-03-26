export default interface IGameStatus {
    IsEnded: boolean;
    NextPlayer: string;
    Winner: string;
    Pizzas: number;
    LastAction: number;
}