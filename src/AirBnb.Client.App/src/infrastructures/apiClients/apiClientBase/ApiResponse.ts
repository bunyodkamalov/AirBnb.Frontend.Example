import type  { ProblemDetails } from "@/infrastructures/apiClients/apiClientBase/ProblemDetails";

export class ApiResponse<T>{
    public response: T | null;
    public error: ProblemDetails | null;
    public status: number;

    constructor(response: T | null, error: ProblemDetails | null, status: number) {
        this.response = response;
        this.status = status;
        this.error = error;
    }

}