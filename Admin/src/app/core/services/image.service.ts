import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiService } from './api.service';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
@Injectable({
  providedIn: 'root',
})
export class UploadService {
  constructor(private http: HttpClient) {}

  // uploadImage(file: File): Promise<any> {
  //   const formData = new FormData();
  //   formData.append('image', file);
  //   return this.http.post('https://localhost:44310/uploadfile', formData).toPromise();
  //   debugger
  // }
  
  // uploadImage(file: File): Promise<any> {
  //   const formData = new FormData();
  //   formData.append('file', file);

  //   const headers = new HttpHeaders();
  //   headers.append('Accept', 'application/json');

  //   return this.http.post('https://localhost:44310/uploadfile', formData, { headers }).toPromise();
  // }
  uploadFile(file: File): void {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const formData: FormData = new FormData();
    formData.append('file', file, file.name);
    debugger;
    this.http
      .post('https://localhost:44310/uploadfile', formData, { headers: headers })
      .subscribe((res)=>{
        console.log(res);
      });
  }

  public post(url: string, model: any): Observable <any> {
    let formData: FormData = new FormData(); 
    formData.append('id', model.id); 
    formData.append('applicationName', model.applicationName); 
    return this.http.post(url, formData)
        .pipe(map((response: any) => response.json()));
}

}