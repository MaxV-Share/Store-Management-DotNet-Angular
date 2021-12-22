import { AutoMap } from "@automapper/classes";
import { BaseUpdateRequest } from "../bases";
import { CategoryDetailUpdateRequest } from "./category-detail-update-request";

export class CategoryUpdateRequest extends BaseUpdateRequest {
    @AutoMap()
    id?: number;
    @AutoMap({ typeFn: () => CategoryDetailUpdateRequest })
    details?: CategoryDetailUpdateRequest[];
    @AutoMap()
    parentId?: number;
}
