import { AfterViewInit, Component, EventEmitter, OnInit, Sanitizer, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import CategoryDetailComponent from '@app/components/category/category-detail/category-detail.component';
import { TranslateService } from '@ngx-translate/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Observable, of, Subscription } from 'rxjs';
import { debounceTime, delay, finalize, map, startWith, switchMap, tap } from 'rxjs/operators';
import { Lang, Category, Product, ProductDetail, ENVIRONMENT, LANGS, CategoryDetail, ProductCreateRequest } from '@app/models';
import { CategoryService, UtilitiesService } from '@app/shared/services';
import { ProductService } from '@app/shared/services/product.service';
import { ToastrService } from 'ngx-toastr';
import { FileUpload } from 'primeng-lts';
import { DomSanitizer } from '@angular/platform-browser';
import { HttpHeaders, HttpResponse } from '@angular/common/http';
import { BaseComponent } from '@app/components/base';
import { mapper } from '../../../models/index';
import { ProductUpdateRequest } from '../../../models/update-requests/product-update-request';
@Component({
    selector: 'app-product-detail',
    templateUrl: './product-detail.component.html',
    styleUrls: ['./product-detail.component.scss']
})
export class ProductDetailComponent extends BaseComponent implements OnInit {

    previewImage: string | undefined = '';
    previewVisible = false;
    showAddCategory = false;
    showEditCategory = false;
    langs: Lang[];
    public productId: number;
    saved: EventEmitter<any> = new EventEmitter();
    entity: Product = new Product();
    ctrCategory = new FormControl();
    options: string[] = ['One', 'Two', 'Three'];
    filteredOptions: Observable<CategoryDetail[]>;
    categories: Observable<CategoryDetail[]>;
    multipleFile: boolean = false;
    isLoadingAutocompleteCategory: boolean;
    private subscription = new Subscription();
    @ViewChild(FileUpload)
    externalFiles: FileUpload;
    productImage: {
        content?: any,
        file?: File
    };

    get productImageUrl() {
        return this.productImage?.content || (this.entity.imageUrl?.length > 0 ? (ENVIRONMENT.fileUrl + this.entity.imageUrl) : null);
    }

    ENVIRONMENT = ENVIRONMENT;

    constructor(private modalService: BsModalService,
        private categoryService: CategoryService,
        private productService: ProductService,
        private utilitiesService: UtilitiesService,
        public bsModalRef: BsModalRef,
        public bsCategoryModalRef: BsModalRef,
        protected toastr: ToastrService,
        public translate: TranslateService,
        private sanitizer: DomSanitizer) {
        super(translate, toastr);
    }

    getEntity() {
        this.entity = {
            id: null,
            imageUrl: "",
            details: [
            ]
        };

        this.langs.forEach(e => {
            this.entity.details.push({
                langId: e.id,
                name: "",
                description: "",
                product: null,
                productId: null
            })
        })
        if (this.productId != null) {
            this.productService.getById(this.productId).subscribe((res: HttpResponse<Product>) => {
                if (res.status == 200) {
                    res.body.imageUrl = res.body.imageUrl?.replace("\\", "/");
                    this.entity = res.body;
                    this.getCategory();
                }
            })
        } else {
            this.getCategory()
        }
    }

    ngOnInit(): void {
        this.productImage = {};
        this.langs = LANGS;
        this.getEntity();

        this.ctrCategory.valueChanges
            .pipe(
                debounceTime(500),
                tap(() => {
                    this.isLoadingAutocompleteCategory = true;
                }), switchMap(searchValue => {
                    this.isLoadingAutocompleteCategory = true;
                    return this.categoryService.getAll(searchValue).pipe(
                        delay(100),
                        finalize(() => {
                            this.isLoadingAutocompleteCategory = false
                        }))
                })
            )
            .subscribe((res: HttpResponse<CategoryDetail[]>) => {
                this.isLoadingAutocompleteCategory = true;
                this.categories = of(res.body);
                this.filteredOptions = of(res.body);
            });
    }

    addFile(event, multipleFile: boolean) {
        let files = event.target.files;
        this.productImage.file = files[0];
        if (files) {
            const reader = new FileReader();

            reader.onload = () => {
                this.productImage.content = reader.result
                console.log(reader.result.toString().split(",")[1]);
            }
            reader.readAsDataURL(files[0]);

        }
    }
    modalRefImageShow: BsModalRef;
    imageShow: any;
    openModal(modelTemplate, img) {
        this.imageShow = img;

        this.modalRefImageShow = this.modalService.show(modelTemplate, {
            animated: true,
            backdrop: 'static',
        });
    }

    onSave() {
        this.entity.categoryId = this.ctrCategory.value.categoryId;
        let formData = new FormData();
        if (this.productImage.file) {
            formData.append('file', this.productImage.file, this.productImage.file.name);
        }
        if (this.entity.id == null) {

            let productCreate = mapper.map(this.entity,ProductCreateRequest,Product);
            console.log(productCreate);
            // formData = this.utilitiesService.ToFormData(productCreate,formData);
            // console.log(productCreate);

            // this.productService.add(formData).subscribe((res: HttpResponse<any>) => {
            //     if (res.status == 200) {
            //         this.translate.get('Success').subscribe(e => {
            //             this.toastr.success(e)
            //         });
            //         this.saved.emit("success");
            //     }
            // }, err => {
            //     this.toastr.error("error");
            //     console.error(err);
            // });
        } else {
            let productUpdate = mapper.map(this.entity,ProductUpdateRequest,Product);
            console.log(productUpdate);
            this.utilitiesService.ToFormData(productUpdate,formData);
            this.productService.update(this.entity.id, formData).subscribe((res: HttpResponse<any>) => {
                if (res.status == 200) {
                    this.translate.get('Success').subscribe(e => {
                        this.toastr.success(e)
                    });
                    this.saved.emit("success");
                }
            })
        }
    }

    changeTab(index: number) {
        // console.log(this.langs[index].id);
        // this.translate.use(this.langs[index].id);
    }

    displayFn(user: CategoryDetail): string {
        return user && user.name ? user.name : '';
    }

    createCategory() {
        const initialState = {
            id: null,
        };

        this.bsCategoryModalRef = this.modalService.show(CategoryDetailComponent, {
            initialState: initialState,
            class: 'modal-lg',
            backdrop: 'static'
        });

        this.bsCategoryModalRef.content.saved.subscribe((e) => {
            this.bsCategoryModalRef.hide();
            this.getCategory();
        });
    }
    submitForm() {

    }

    editCategory(categoryId) {
        const initialState = {
            id: categoryId,
        };

        this.bsCategoryModalRef = this.modalService.show(CategoryDetailComponent, {
            initialState: initialState,
            class: 'modal-lg',
            backdrop: 'static',
            focus: false
        });

        this.bsCategoryModalRef.content.saved.subscribe((e) => {
            this.bsCategoryModalRef.hide();
            this.getCategory();
        });
    }
    getCategory() {
        this.categoryService.getAll().subscribe((res: HttpResponse<CategoryDetail[]>) => {
            if (res.status == 200) {
                this.categories = of(res.body);
                this.ctrCategory.setValue(res.body.find(e => e.categoryId == this.entity.categoryId));
                this.filteredOptions = this.ctrCategory.valueChanges
                    .pipe(
                        startWith(''),
                        map(value => typeof value === 'string' ? value : value.name),
                        map(name => res.body.slice())
                    );
            }
        })
    }
}
