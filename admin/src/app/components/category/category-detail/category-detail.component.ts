import { Component, EventEmitter, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Category, Lang } from '@app/models';

@Component({
  selector: 'app-category-detail',
  templateUrl: './category-detail.component.html',
  styleUrls: ['./category-detail.component.scss']
})
export default class CategoryDetailComponent implements OnInit {

    constructor(private modalService: NgbModal, public bsModalRef: BsModalRef, public translate: TranslateService) {

    }
    langs: Lang[];
    public id: number;
    saved: EventEmitter<any> = new EventEmitter();
    entity: Category;
  ngOnInit() {
  }
  onSave() {
      // this.saved.emit("Saved");
      //console.log(this.entity);
  }

}
