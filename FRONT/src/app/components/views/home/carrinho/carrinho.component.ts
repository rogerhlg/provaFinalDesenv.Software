import { Component, OnInit } from "@angular/core";
import { ItemVenda } from "src/app/models/item-venda";
import { ItemService } from "src/app/services/item.service";
import { Router } from "@angular/router";

@Component({
    selector: "app-carrinho",
    templateUrl: "./carrinho.component.html",
    styleUrls: ["./carrinho.component.css"],
})
export class CarrinhoComponent implements OnInit {
    itens: ItemVenda[] = [];
    colunasExibidas: String[] = ["nome", "preco", "quantidade", "imagem"];
    valorTotal!: number;
    constructor(private itemService: ItemService, private router: Router) {}

    ngOnInit(): void {
        let carrinhoId = localStorage.getItem("carrinhoId")! || "";
        this.itemService.getByCartId(carrinhoId).subscribe((itens) => {
            this.itens = itens;
            this.valorTotal = this.itens.reduce((total, item) => {
                return total + item.preco * item.quantidade;
            }, 0);
        });
    }
    comprar() : void {
        this.router.navigate(["venda/criar"]);
    }
}
