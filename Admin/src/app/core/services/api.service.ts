import { environment } from './../../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import {map } from 'rxjs/operators'
@Injectable({
    providedIn: 'root',
})


export class ApiService {
    public host = environment.BASE_API;
    constructor(private _http: HttpClient, public router: Router) { }

    public post(url: string, obj: any) {
        const body = new FormData();
        body.append('file', obj.value1); // Thêm dữ liệu value1 với khóa key1
        return this._http.post<any>(this.host + url, body).pipe(
          map((res: any) => {
            return res;
          })
        );
      }
   
    public get(url: string) {
        let cloneHeader: any = {};
        cloneHeader['Content-Type'] = 'application/json';
        const headerOptions = new HttpHeaders(cloneHeader);

        return this._http
            .get(this.host + url, { headers: headerOptions })
            .pipe(
                map((res: any) => {
                    return res;
                })
            );

    }
    public uploadFileSingle(url: string, folder: string, file: Blob) {
        const formData = new FormData();
        formData.append('file', file);
        formData.append('folder', folder);
        return this._http.post(this.host + url, formData, {reportProgress: true, observe: 'events' })
    }

    public uploadFileMulti(url: string, folder: string, ...file: Blob[]) {
        const formData = new FormData();
        file.forEach(x => {
            formData.append('files', x);
        });
        formData.append('folder', folder);
        return this._http.post(this.host + url, formData, { reportProgress: true, observe: 'events' })
    }

    uploadFiles(file: File): Observable<any> {
        const url = 'https://localhost:44310/api/FileUpload'; // Thay thế bằng URL thực tế của API endpoint
        console.log(file);
        const formData = new FormData();
        formData.append('file', file); // Thay 'file' bằng tên trường tương ứng trong API
        const headers = new HttpHeaders();
        // Đảm bảo Content-Type phù hợp
        console.log(formData.getAll('file'))

        headers.append('Content-Type', 'multipart/form-data');
        console.log(formData);
        return this._http.post(url, formData, { headers });
        
      }
}
