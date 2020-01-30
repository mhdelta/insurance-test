export class Policy {
    id: number
    nombre: string
    descripcion: string
    inicioVigencia: string
    mesesCobertura: string
    precio: number
    tipoCubrimiento: number
    tipoRiesgo: number
    tipoCubrimientoNavigation?: string
    tipoRiesgoNavigation?: string
}