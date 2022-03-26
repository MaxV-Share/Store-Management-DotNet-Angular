import { IBaseViewModel } from 'models';

export interface ICategoryDetailAddOrUpdateModel extends IBaseViewModel<number> {
  categoryId?: number,
  langId: string,
  name: string,
  description: string,
}
