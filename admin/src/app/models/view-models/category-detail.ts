import { BaseViewModel,Category } from "@app/models";

export class CategoryDetail  extends BaseViewModel<number> {
    langId: string;
    categoryId: number;
    category: Category;
    name: string;
    description: string;
}
