import { BaseCreateRequest, CategoryDetailCreateRequest } from "@app/models";

export class CategoryCreateRequest extends BaseCreateRequest {
    details?: CategoryDetailCreateRequest[] = [];
    parentId?: number = null;
}
