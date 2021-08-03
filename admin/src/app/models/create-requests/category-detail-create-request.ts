import { BaseCreateRequest } from "@app/models";
import { AutoMap } from "@automapper/classes";


export class CategoryDetailCreateRequest extends BaseCreateRequest {
    @AutoMap()
    langId: string;
    @AutoMap()
    name: string;
    @AutoMap()
    description: string;
}
