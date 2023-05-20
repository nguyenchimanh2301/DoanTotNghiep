import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class UploadService {
  constructor(private http: HttpClient) {}

  uploadImage(file: File): Promise<any> {
    const formData = new FormData();
    formData.append('file', file);

    return this.http.post('/api/upload', formData).toPromise();
  }
}