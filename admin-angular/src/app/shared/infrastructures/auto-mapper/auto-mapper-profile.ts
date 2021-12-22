import * as Models  from '@app/models';
import type { MappingProfile } from '@automapper/types';

export const autoMapperProfile: MappingProfile = (mapper) => {
    mapper.createMap(Models.BillDetail, Models.BillDetailCreateRequest);
    mapper.createMap(Models.BillDetail, Models.BillDetailUpdateRequest);

    mapper.createMap(Models.Bill, Models.BillCreateRequest);
    mapper.createMap(Models.Bill, Models.BillUpdateRequest);

    mapper.createMap(Models.CategoryDetail, Models.CategoryDetailCreateRequest);
    mapper.createMap(Models.CategoryDetail, Models.CategoryDetailUpdateRequest);

    mapper.createMap(Models.Category, Models.CategoryCreateRequest);
    mapper.createMap(Models.Category, Models.CategoryUpdateRequest);

    mapper.createMap(Models.FunctionViewModel, Models.FunctionCreateRequest);
    mapper.createMap(Models.FunctionViewModel, Models.FunctionUpdateRequest);

    mapper.createMap(Models.Discount, Models.DiscountCreateRequest);
    mapper.createMap(Models.Discount, Models.DiscountUpdateRequest);

    mapper.createMap(Models.Product, Models.ProductCreateRequest);
    mapper.createMap(Models.Product, Models.ProductUpdateRequest);

    mapper.createMap(Models.ProductDetail, Models.ProductDetailCreateRequest);
    mapper.createMap(Models.ProductDetail, Models.ProductDetailUpdateRequest);
};
