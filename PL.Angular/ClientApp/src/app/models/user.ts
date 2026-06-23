import { UserRole } from './enums/user-role.enum';

export class User {
    constructor(
        public id: string = '',
        public email: string = '',
        public role: UserRole = UserRole.Guest
    ) {}
}