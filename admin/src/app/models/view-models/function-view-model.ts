import { AutoMap } from "@automapper/classes";
import { BaseViewModel } from "..";

export class FunctionViewModel extends BaseViewModel{
    @AutoMap()
    id?: string;
    @AutoMap()
    name: string;
    @AutoMap()
    url: string;
    @AutoMap()
    sortOrder: number;
    @AutoMap()
    parentId: string;
    @AutoMap()
    icon: string;
    hasChildren: boolean;
    childrens: FunctionViewModel[];
}
