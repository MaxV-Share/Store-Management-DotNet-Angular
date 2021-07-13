import { Observable } from "rxjs";

export interface IBaseService<TCreateRequest,T> {
    add(entity: TCreateRequest): Observable<Object>;
    update(id: number, entity: T): Observable<Object>;
    getPaging(pageIndex: number, pageSize: number, searchText: string): Observable<Object>;
}
