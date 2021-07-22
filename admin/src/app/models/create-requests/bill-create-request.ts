import { BaseCreateRequest } from '@app/models';
import { BillDetailCreateRequest } from '@app/models/create-requests';


export class BillCreateRequest extends BaseCreateRequest {
    customerPhoneNumber: string = '';
    customerFullName: string = '';
    customerAddress: string = '';
    userPaymentId?: string = null;
    userPaymentUserName: string = null;
    totalPrice: number = 0;
    discountPrice: number = 0;
    paymentAmount: number = 0;
    billDetails: BillDetailCreateRequest[] = []
}
