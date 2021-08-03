import { AutoMap } from "@automapper/classes";

export class Revenue {
    @AutoMap()
    id: string;
    @AutoMap()
    totalPrice :number;
}
