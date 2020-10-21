export interface User {
    employeeId: string;
    name: string;
    designation: string;
    email: string;
    phoneNumber: string;
    role: string;
    supervisorId: string;
    token?: string;
    address: string
  }