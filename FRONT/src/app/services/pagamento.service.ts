import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Pagamento } from "../models/pagamento";

@Injectable({
    providedIn: "root",
})
export class PagamentoService {
    private baseUrl = "http://localhost:5000/api/pagamento";

    constructor(private http: HttpClient) {}

    list(): Observable<Pagamento[]> {
        return this.http.get<Pagamento[]>(`${this.baseUrl}/list`);
    }
}
