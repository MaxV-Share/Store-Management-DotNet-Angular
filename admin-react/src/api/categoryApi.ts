import { IBasePaging, ICategoryViewModel } from '../models';
import { IFilterBodyRequest } from '../models/Bases/IFilterBodyRequest';
import axiosClient from './axiosClient';

const categoryApi = {
  getAll(data: IFilterBodyRequest): Promise<IBasePaging<ICategoryViewModel>> {
    const url = '/categories/filter';
    return axiosClient.post(url, data);
  },
  getById(id: string): Promise<ICategoryViewModel> {
    const url = `/categories/${id}`;
    return axiosClient.get(url);
  },
  add(data: ICategoryViewModel): Promise<ICategoryViewModel> {
    const url = '/categories';
    return axiosClient.post(url, data);
  },
  update(data: Partial<ICategoryViewModel>): Promise<ICategoryViewModel> {
    const url = `/categories/${data.id}`;
    return axiosClient.patch(url, data);
  },
  remove(id: string): Promise<any> {
    const url = `/categories/${id}`;
    return axiosClient.delete(url);
  },
};

export default categoryApi;