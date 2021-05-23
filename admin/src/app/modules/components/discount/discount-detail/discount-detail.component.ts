import { AfterViewInit, Component, EventEmitter, OnInit } from '@angular/core';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Discount } from '../../../../models';

@Component({
    selector: 'app-discount-detail',
    templateUrl: './discount-detail.component.html',
    styleUrls: ['./discount-detail.component.scss']
})
export class DiscountDetailComponent implements OnInit{

    constructor(private modalService: NgbModal, public bsModalRef: BsModalRef,) {

    }
    public entity: Discount;
    saved: EventEmitter<any> = new EventEmitter();
    ngOnInit(): void {
        console.log(this.entity);
    }


    // open(content) {
    //     this.modalService.open(content).result.then(
    //         (result) => {
    //             this.closeResult = `Closed with: ${result}`;
    //         },
    //         (reason) => {
    //             this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    //         }
    //     );
    // }

    // private getDismissReason(reason: any): string {
    //     if (reason === ModalDismissReasons.ESC) {
    //         return 'by pressing ESC';
    //     } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
    //         return 'by clicking on a backdrop';
    //     } else {
    //         return `with: ${reason}`;
    //     }
    // }
}
