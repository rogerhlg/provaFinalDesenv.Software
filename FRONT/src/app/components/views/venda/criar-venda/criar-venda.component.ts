import { Component, OnInit } from '@angular/core';
import { PagamentoService } from "src/app/services/pagamento.service";
import { Pagamento } from "src/app/models/pagamento";
import { Venda } from 'src/app/models/venda';
import { VendaService } from 'src/app/services/venda.service';
import { Router } from "@angular/router";
import { ItemService } from 'src/app/services/item.service';
import { ItemVenda } from 'src/app/models/item-venda';


@Component({
  selector: 'app-criar-venda',
  templateUrl: './criar-venda.component.html',
  styleUrls: ['./criar-venda.component.css']
})
export class CriarVendaComponent implements OnInit {
  pagamentos: Pagamento[] = []
  pagamentoId!: number;
  nome!: string;
  carrinhoId!: string;
  itens: ItemVenda[] = [];

  constructor(private pagamentoService: PagamentoService, private vendaService: VendaService, private itemService: ItemService, private router: Router) { }

  ngOnInit(): void {
    this.pagamentoService.list().subscribe((pagamentos) => {
      console.log(pagamentos);
      this.pagamentos = pagamentos;
    });
    this.carrinhoId = localStorage.getItem("carrinhoId")! || ""
    
    // this.itemService.getByCartId(this.carrinhoId).subscribe((itens) => {
    //   this.itens = itens;
    // })

  }

  comprar(): void {
    if(this.nome && this.nome.length > 0 && this.pagamentoId){
      let venda: Venda = {
        cliente: this.nome,
        pagamentoId: this.pagamentoId,
        carrinhoId: this.carrinhoId,
      }
  
      this.vendaService.create(venda).subscribe((venda) => {
        console.log(venda);
        this.router.navigate([""]);
      })
    }
    else{
      alert('Digite todos os campos!');
    }
  }

}
