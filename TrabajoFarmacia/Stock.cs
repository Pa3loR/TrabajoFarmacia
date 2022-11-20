using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoFarmacia
{

    /// *********************************************
    /// CLASE PARA CONTROLAR EL STOCK DE MEDICAMENTOS
    /// *********************************************
    internal class Stock
    {
        // ATRIBUTOS
        private int cantDisponible;
        private Medicamento medicine;

        // CONSTRUCTOR
        public Stock(Medicamento Medicine, int cantidad = 0)
        {
            cantDisponible = cantidad;
            medicine = Medicine;
        }
        // METODOS DE SOLO LECTURA 
        public int CantDisponible { get { return cantDisponible; } }
        public Medicamento Medicine { get { return medicine; } }

        //METODO PARA AGREGAR NUEVA CANTIDAD AL STOCK
        //-- agrega 1 si no se agrega valores
        public void Add() => cantDisponible++;
        //-- agrega la cantidad marcada
        public void Add(int agregar) => cantDisponible += agregar;

        // METODO PARA QUITAR CANTIDAD DEL STOCK
        //-- quita 1 solo 
        public void Delete()
        {
            if (!(cantDisponible == 0)) // solo elimina si es mayor a 0 por que no puede existir stock negativo
                cantDisponible--;
            else Console.WriteLine("No se puede quitar por que el stok del medicamento es nulo");
        }
        //-- quita la cantidad ingresada
        public void Delete(int cantidadEliminar) => cantDisponible -= cantidadEliminar;

        //METODO PARA VERFICAR SI NO HAY CANTIDAD DISPONIBLE DE STOCK
        public bool IsEmptyStok()
        {
            if (cantDisponible == 0) return true;
            return false;
        }

        // METODO PARA VER SI LA CANTIDAD CORESPONDE A UNA CANTIDAD SOLICITADA
        public bool CheckStok(int cant)
        {
            if (cantDisponible >= cant) return true;
            return false;
        }

        // SOBREESCREITURA DEL METODO BASE TOSTRING
        public override string ToString()
        {
            return medicine + ": Cantidad disponible " + cantDisponible;
        }
        // DESTRUCTOR
        ~Stock()
        {
            medicine = null;
        }
    }
}
