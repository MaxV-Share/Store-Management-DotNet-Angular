import { BaseViewModel,Category } from "@app/models";
import { AutoMap } from "@automapper/classes";

export class CategoryDetail  extends BaseViewModel {
    @AutoMap()
    id?: number;
    @AutoMap()
    langId?: string;
    @AutoMap()
    categoryId?: number;
    @AutoMap()
    category?: Category;
    @AutoMap()
    name?: string;
    @AutoMap()
    description?: string;
}
