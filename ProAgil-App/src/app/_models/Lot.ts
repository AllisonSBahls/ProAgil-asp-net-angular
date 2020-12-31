export interface Lot {
    id: number;
    name: string;
    price: number;
    initial?: Date;
    final?: Date;
    quantity: number;
    eventId: number;
}
