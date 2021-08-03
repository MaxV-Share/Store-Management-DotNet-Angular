import { AutoMap } from "@automapper/classes";
import { BaseUpdateRequest } from "..";

export class FunctionUpdateRequest extends BaseUpdateRequest {
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
