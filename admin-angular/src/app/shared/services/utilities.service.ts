import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class UtilitiesService {
    constructor(http: HttpClient) {
    }
    UnflatteringForLeftMenu = (arr: any[]): any[] => {
        const map = {};
        const roots: any[] = [];
        for (let i = 0; i < arr.length; i++) {
            const node = arr[i];
            node.children = [];
            map[node.id] = i; // use map to look-up the parents
            if (node.parentId !== null) {
                delete node['children'];
                arr[map[node.parentId]].children.push(node);
            } else {
                roots.push(node);
            }
        }
        return roots;
    }

    UnflatteringForTree = (arr: any[]): any[] => {
        const map = {};
        const roots: any[] = [];
        let node = {
            data: {
                id: '',
                parentId: ''
            },
            expanded: true,
            children: []
        };
        for (let i = 0; i < arr.length; i += 1) {
            map[arr[i].id] = i; // initialize the map
            arr[i].data = arr[i]; // initialize the data
            arr[i].children = []; // initialize the children
        }
        for (let i = 0; i < arr.length; i += 1) {
            node = arr[i];
            if (node.data.parentId !== null && arr[map[node.data.parentId]] != undefined) {
                arr[map[node.data.parentId]].children.push(node);
            } else {
                roots.push(node);
            }
        }
        return roots;
    }


    b64toBlob(b64Data, contentType = '', sliceSize = 512) {
        const byteCharacters = atob(b64Data);
        const byteArrays = [];

        for (let offset = 0; offset < byteCharacters.length; offset += sliceSize) {
            const slice = byteCharacters.slice(offset, offset + sliceSize);

            const byteNumbers = new Array(slice.length);
            for (let i = 0; i < slice.length; i++) {
                byteNumbers[i] = slice.charCodeAt(i);
            }

            const byteArray = new Uint8Array(byteNumbers);
            byteArrays.push(byteArray);
        }

        const blob = new Blob(byteArrays, { type: contentType });
        return blob;
    }

    // ToFormData(formValue: any): FormData {
    //     const formData = new FormData();
    //     for (const key of Object.keys(formValue)) {
    //         const value = formValue[key];

    //         // if (typeof value === 'object') {
    //         //     var blob = new Blob([value], { type: 'application/json' });
    //         //     formData.append(key, blob)
    //         // }
    //         // else {
    //             formData.append(key, value);
    //         //}

    //     }

    //     return formData;
    // }

    ToFormData(object: Object, formData = new FormData(), namespace: string | undefined = undefined): FormData {
        for (let property in object) {
            if (!object.hasOwnProperty(property) || !object[property]) {
                continue;
            }
            const formKey = namespace ? `${namespace}[${property}]` : property;
            if (object[property] instanceof Date) {
                formData.append(formKey, object[property].toISOString());
            } else if (typeof object[property] === 'object' && !(object[property] instanceof File)) {
                this.ToFormData(object[property], formData, formKey);
            } else {
                formData.append(formKey, object[property]);
            }
        }
        return formData;
    }
    MakeSeoTitle(input: string) {
        if (input == undefined || input == '') {
            return '';
        }
        // ?????i ch??? hoa th??nh ch??? th?????ng
        let slug = input.toLowerCase();

        // ?????i k?? t??? c?? d???u th??nh kh??ng d???u
        slug = slug.replace(/??|??|???|???|??|??|???|???|???|???|???|??|???|???|???|???|???/gi, 'a');
        slug = slug.replace(/??|??|???|???|???|??|???|???|???|???|???/gi, 'e');
        slug = slug.replace(/i|??|??|???|??|???/gi, 'i');
        slug = slug.replace(/??|??|???|??|???|??|???|???|???|???|???|??|???|???|???|???|???/gi, 'o');
        slug = slug.replace(/??|??|???|??|???|??|???|???|???|???|???/gi, 'u');
        slug = slug.replace(/??|???|???|???|???/gi, 'y');
        slug = slug.replace(/??/gi, 'd');
        // X??a c??c k?? t??? ?????t bi???t
        slug = slug.replace(/\`|\~|\!|\@|\#|\||\$|\%|\^|\&|\*|\(|\)|\+|\=|\,|\.|\/|\?|\>|\<|\'|\"|\:|\;|_/gi, '');
        // ?????i kho???ng tr???ng th??nh k?? t??? g???ch ngang
        slug = slug.replace(/ /gi, '-');
        // ?????i nhi???u k?? t??? g???ch ngang li??n ti???p th??nh 1 k?? t??? g???ch ngang
        // Ph??ng tr?????ng h???p ng?????i nh???p v??o qu?? nhi???u k?? t??? tr???ng
        slug = slug.replace(/\-\-\-\-\-/gi, '-');
        slug = slug.replace(/\-\-\-\-/gi, '-');
        slug = slug.replace(/\-\-\-/gi, '-');
        slug = slug.replace(/\-\-/gi, '-');
        // X??a c??c k?? t??? g???ch ngang ??? ?????u v?? cu???i
        slug = '@' + slug + '@';
        slug = slug.replace(/\@\-|\-\@|\@/gi, '');

        return slug;
    }
}
