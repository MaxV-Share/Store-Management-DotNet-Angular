import { AutoMap } from "@automapper/classes";

export class BaseViewModel {
    @AutoMap()
    createAt?: Date ;
    @AutoMap()
    updateAt?: Date ;
    @AutoMap()
    createBy?: Date;
    @AutoMap()
    updateBy?: Date ;
}
