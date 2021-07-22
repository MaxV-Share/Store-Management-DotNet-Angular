import { BaseCreateRequest } from "@app/models";


export class CategoryDetailCreateRequest extends BaseCreateRequest  {
    langId: string;
    name: string;
    description: string;
}
