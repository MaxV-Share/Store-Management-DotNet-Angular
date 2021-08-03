import { BaseCreateRequest, CategoryDetailCreateRequest } from "@app/models";
import { AutoMap } from "@automapper/classes";

export class CategoryCreateRequest extends BaseCreateRequest {
    @AutoMap({ typeFn: () => CategoryDetailCreateRequest })
    details?: CategoryDetailCreateRequest[];
    @AutoMap()
    parentId?: number = null;
}
