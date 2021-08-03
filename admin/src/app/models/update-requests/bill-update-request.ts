import { BaseUpdateRequest, BillDetail } from '@app/models';
import { AutoMap } from '@automapper/classes';


export class BillUpdateRequest extends BaseUpdateRequest {
    @AutoMap()
    id?: number;
    @AutoMap()
    customerPhoneNumber?: string;
    @AutoMap()
    customerFullName?: string;
    @AutoMap()
    customerAddress?: string;
    @AutoMap()
    userPaymentId?: string;
    @AutoMap()
    userPaymentUserName?: string;
    @AutoMap()
    totalPrice: number;
    @AutoMap()
    discountPrice?: number ;
    @AutoMap()
    paymentAmount?: number ;
    @AutoMap({ typeFn: () => BillDetail })
    billDetails: BillDetail[];
}
