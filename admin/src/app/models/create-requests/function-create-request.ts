import { AutoMap } from "@automapper/classes";
import { BaseCreateRequest } from "..";

export class FunctionCreateRequest extends BaseCreateRequest {
    @AutoMap()
    id?: string;
    @AutoMap()
    name: string;
    @AutoMap()
    url: string;
    @AutoMap()
    sortOrder: number;
    @AutoMap()
    parentId: string;
    @AutoMap()
    icon: string;
}
