import { Observable } from "rxjs";

export interface IBaseService<TCreateRequest,T> {
    add(entity: TCreateRequest);
    update(id: number, entity: T);
    getPaging(pageIndex: number, pageSize: number, searchText: string);
}
