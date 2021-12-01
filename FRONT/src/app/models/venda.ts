import { Pagamento } from "./pagamento";

export interface Venda {
    vendaId?: number;
    cliente: string;
    carrinhoId: string;
    pagamentoId: number;
    // pagamento: Pagamento;
}
