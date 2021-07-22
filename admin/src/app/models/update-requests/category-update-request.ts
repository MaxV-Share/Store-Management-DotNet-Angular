import { BaseUpdateRequest } from "../bases";
import { CategoryDetailUpdateRequest } from "./category-detail-update-request";

export class CategoryUpdateRequest extends BaseUpdateRequest<number> {
    details?: CategoryDetailUpdateRequest[] = [];
    parentId?: number = null;
}
