import { BaseCreateRequest } from '@app/models';
import { BillDetailCreateRequest } from '@app/models/create-requests';
import { AutoMap } from '@automapper/classes';


export class BillCreateRequest extends BaseCreateRequest {

    @AutoMap()
    customerPhoneNumber: string;
    @AutoMap()
    customerFullName: string;
    @AutoMap()
    customerAddress: string;
    @AutoMap()
    userPaymentId?: string;
    @AutoMap()
    userPaymentUserName: string;
    @AutoMap()
    totalPrice: number;
    @AutoMap()
    discountPrice: number;
    @AutoMap()
    paymentAmount: number;
    @AutoMap({ typeFn: () => BillDetailCreateRequest })
    billDetails: BillDetailCreateRequest[];
}
