import { BaseViewModel } from "@app/models";
import { AutoMap } from "@automapper/classes";
import { CategoryDetail } from './category-detail';

export class Category  extends BaseViewModel  {
    @AutoMap()
    id?: number;
    @AutoMap()
    parentId?: string;
    @AutoMap({ typeFn: () => CategoryDetail })
    details?: CategoryDetail[];
}
