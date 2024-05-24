using Ista.Consola.Infraestructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ista.Comunes {
    public class Elemento<K, V> {
        public K Key {  get; set; }
        public V Value { get; set;}

        public Elemento(K key, V value) {
            Key = key;
            Value = value;
        }
    }
    public class ElementoCadena<K> : Elemento<K, string> {
        public ElementoCadena(K key, string value) : base(key, value) {
        }
    }
}
