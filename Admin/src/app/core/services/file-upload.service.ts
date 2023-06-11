import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class FileUploadService {
  constructor(private http: HttpClient) { }

  uploadFile(file: File): Promise<any> {
    const formData: FormData = new FormData();
    formData.append('file', file, file.name);
    
    return this.http.post<any>('https://localhost:44310/api/FileUpload', formData, {
      reportProgress: true,
      responseType: 'json'
    }).toPromise();
  }
  
}
