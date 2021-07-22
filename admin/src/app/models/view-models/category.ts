import { BaseViewModel } from "@app/models";
import { CategoryDetail } from './category-detail';

export class Category  extends BaseViewModel<number>  {
    parentId: string;
    details?: CategoryDetail[] = []; //
}
