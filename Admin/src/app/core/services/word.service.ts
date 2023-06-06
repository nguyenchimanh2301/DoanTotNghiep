import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import Docxtemplater from 'docxtemplater';

import { saveAs } from 'file-saver';
import * as JSZip from 'jszip';
@Injectable({
  providedIn: 'root'
})
export class WordService {
  constructor(private http: HttpClient) {}

  generateWordDocument(data: any): void {
    // Lấy template file Word từ server
    this.http.get('path/to/template.docx', { responseType: 'arraybuffer' }).subscribe(template => {
      const doc = new Docxtemplater();
      doc.loadZip(new JSZip(template));
      
      // Thiết lập dữ liệu để thay thế trong template
      doc.setData(data);
      
      // Compile template
      doc.render();

      // Chuyển đổi file Word sang ArrayBuffer
      const generatedDoc = doc.getZip().generate({ type: 'arraybuffer' });

      // Lưu và tải xuống file Word
      const blob = new Blob([generatedDoc], { type: 'application/vnd.openxmlformats-officedocument.wordprocessingml.document' });
      saveAs(blob, 'output.docx');
    });
  }
}