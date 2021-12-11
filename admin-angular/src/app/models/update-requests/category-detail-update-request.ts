import { AutoMap } from "@automapper/classes";
import { BaseUpdateRequest } from "../bases";


export class CategoryDetailUpdateRequest extends BaseUpdateRequest {
    @AutoMap()
    id?: number;
    @AutoMap()
    langId: string;
    @AutoMap()
    name: string;
    @AutoMap()
    description: string;
}
