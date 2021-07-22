import { BaseUpdateRequest } from "../bases";


export class CategoryDetailUpdateRequest  extends BaseUpdateRequest<number>  {
    langId: string = null;
    name: string = null;
    description: string = null;
}
