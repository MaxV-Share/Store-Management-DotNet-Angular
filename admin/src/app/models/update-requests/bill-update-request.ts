import { BaseUpdateRequest, BillDetail } from '@app/models';


export class BillUpdateRequest extends BaseUpdateRequest<number> {
    customerPhoneNumber?: string = null;
    customerFullName?: string = null;
    customerAddress?: string = null;
    userPaymentId?: string = null;
    userPaymentUserName?: string = null;
    totalPrice: number = null;
    discountPrice?: number = null;
    paymentAmount?: number = null;
    billDetails: BillDetail[] = [];
}
