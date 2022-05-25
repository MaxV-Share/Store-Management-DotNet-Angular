import { IBaseViewModel } from 'models';
export interface IFunctionModel extends IBaseViewModel<string> {
  icon?: string,
  sortOrder?: number,
  url?: string,
  parentId?: string,
  langId?: string,
  name?: string,
}