import { Role } from "./role";

export class User {
    id!: string;
    taiKhoan!: string;
    matKhau!: string;
    hoTen!: string;
    diaChi!: string;
    dienThoai!: string;
    email?: string;
    role?: Role;
    token?: string;
}