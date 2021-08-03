import { AutoMap } from "@automapper/classes";

export class Lang {
    @AutoMap()
    id?: string;
    @AutoMap()
    name: string
}
