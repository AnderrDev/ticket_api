
using TicketingSystem.Models;
using Newtonsoft.Json;
namespace TicketingSystem.Repositories
{

    public static class TicketRepository
    {
        // Obtener todos los tickets del archivo datos.json
        public static Ticket[] GetAll()
        {
            try
            {
                // Leer el contenido del archivo datos.json
                string json = File.ReadAllText("datos.json");

                // Parsear el contenido del archivo datos.json a un arreglo de objetos no tipados
                var ticketsData = JsonConvert.DeserializeObject<dynamic[]>(json);

                // Validar que no sea nulo
                if (ticketsData == null)
                {
                    throw new Exception("El archivo datos.json está vacío");
                }

                // Crear una lista de objetos Ticket
                List<Ticket> ticketList = new List<Ticket>();

                // Agregar los datos de los tickets a la lista de objetos Ticket
                // Agregar los datos de los tickets a la lista de objetos Ticket
                foreach (dynamic ticketData in ticketsData)
                {
                    Ticket ticket = null;
                    // Deserializar el objeto no tipado en un objeto Ticket
                    try
                    {
                        ticket = JsonConvert.DeserializeObject<Ticket>(ticketData.ToString());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    if (ticket != null)
                    {
                        // Agregar el objeto Ticket a la lista de objetos Ticket
                        ticketList.Add(ticket);
                    }
                }

                // Retornar el arreglo de objetos Ticket
                return ticketList.ToArray();
            }
            catch (Exception ex)
            {
                // Si hay algún error al leer o deserializar el archivo, lanzar una excepción con un mensaje de error
                throw new Exception("Error al obtener los tickets: " + ex.Message);
            }
        }

        public static Ticket Get(int id)
        {
            // Obtener el ticket con el id especificado del archivo datos.json
            try
            {
                // Leer el contenido del archivo datos.json
                string json = File.ReadAllText("datos.json");

                var ticketsData = JsonConvert.DeserializeObject<dynamic[]>(json);

                // Validar que no sea nulo
                if (ticketsData == null)
                {
                    throw new Exception("El archivo datos.json está vacío");
                }

                // Buscar el ticket con el id especificado
                foreach (dynamic ticketData in ticketsData)
                {
                    Ticket ticket = null;
                    // Deserializar el objeto no tipado en un objeto Ticket
                    try
                    {
                        ticket = JsonConvert.DeserializeObject<Ticket>(ticketData.ToString());

                        // Si el id del ticket coincide con el id especificado, retornar el ticket
                        if (ticket.Id == id)
                        {
                            return ticket;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    // Si el id del ticket coincide con el id especificado, retornar el ticket
                    if (ticket != null && ticket.Id == id)
                    {
                        return ticket;
                    }
                }

                // Si no se encuentra el ticket, retornar un ticket con datos vacíos
                return new Ticket { Id = 0, User = "", CreationDate = "", UpdateDate = "", Status = "" };
            }
            catch (Exception ex)
            {
                // Si hay algún error al leer o deserializar el archivo, lanzar una excepción con un mensaje de error
                throw new Exception("Error al obtener el ticket: " + ex.Message);
            }
        }

        public static void Delete(int id)
        {
            // Eliminar el ticket con el id especificado del archivo datos.json
            try
            {
                // Leer el contenido del archivo datos.json
                string json = File.ReadAllText("datos.json");

                var ticketsData = JsonConvert.DeserializeObject<dynamic[]>(json);

                // Validar que no sea nulo
                if (ticketsData == null)
                {
                    throw new Exception("El archivo datos.json está vacío");
                }

                int index = 0;
                // Buscar el ticket con el id especificado
                foreach (dynamic ticketData in ticketsData)
                {
                    Ticket ticket = null;
                    // Deserializar el objeto no tipado en un objeto Ticket
                    try
                    {
                        ticket = JsonConvert.DeserializeObject<Ticket>(ticketData.ToString());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    // Si el id del ticket coincide con el id especificado, eliminar el ticket
                    if (ticket != null && ticket.Id == id)
                    {
                        // Eliminar el ticket del arreglo de tickets
                        ticketsData[index] = null;
                        break;
                    }

                    index++;
                }
                // Escribir el contenido del archivo datos.json
                File.WriteAllText("datos.json", JsonConvert.SerializeObject(ticketsData));
            }
            catch (Exception ex)
            {
                // Si hay algún error al leer o deserializar el archivo, lanzar una excepción con un mensaje de error
                throw new Exception("Error al eliminar el ticket: " + ex.Message);
            }
        }


        public static void Update(Ticket ticket)
        {
            // Actualizar el ticket con el id especificado del archivo datos.json
            try
            {
                // Leer el contenido del archivo datos.json
                string json = File.ReadAllText("datos.json");

                var ticketsData = JsonConvert.DeserializeObject<dynamic[]>(json);

                // Validar que no sea nulo
                if (ticketsData == null)
                {
                    throw new Exception("El archivo datos.json está vacío");
                }

                int index = 0;
                // Buscar el ticket con el id especificado
                foreach (dynamic ticketData in ticketsData)
                {

                    Ticket t = null;
                    // Deserializar el objeto no tipado en un objeto Ticket
                    try
                    {
                        t = JsonConvert.DeserializeObject<Ticket>(ticketData.ToString());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    // Si el id del ticket coincide con el id especificado, actualizar el ticket
                    if (t != null && t.Id == ticket.Id)
                    {
                        // Actualizar el ticket en el arreglo de tickets
                        ticketsData[index] = JsonConvert.SerializeObject(ticket);
                        break;
                    }

                    index++;

                }
                // Escribir el contenido del archivo datos.json
                File.WriteAllText("datos.json", JsonConvert.SerializeObject(ticketsData));

            }
            catch (Exception ex)
            {
                // Si hay algún error al leer o deserializar el archivo, lanzar una excepción con un mensaje de error
                throw new Exception("Error al actualizar el ticket: " + ex.Message);
            }
        }

        public static void Save(Ticket ticket)
        {
            // Guardar el ticket en el archivo datos.json
            try
            {
                // Leer el contenido del archivo datos.json
                string json = File.ReadAllText("datos.json");

                var ticketsData = JsonConvert.DeserializeObject<dynamic[]>(json);

                // Validar que no sea nulo
                if (ticketsData == null)
                {
                    throw new Exception("El archivo datos.json está vacío");
                }

                // Crear un nuevo objeto Ticket con los datos del ticket especificado
                Ticket newTicket = new Ticket
                {
                    Id = ticketsData.Length + 1,
                    User = ticket.User,
                    CreationDate = ticket.CreationDate,
                    UpdateDate = ticket.UpdateDate,
                    Status = ticket.Status
                };

                // Agregar el ticket al arreglo de tickets
                ticketsData = ticketsData.Append(JsonConvert.SerializeObject(newTicket)).ToArray();

                // imprimir el arreglo de tickets
                Console.WriteLine("Arreglo de tickets: " + JsonConvert.SerializeObject(ticketsData));
                // Escribir el contenido del archivo datos.json
                File.WriteAllText("datos.json", JsonConvert.SerializeObject(ticketsData));
                Console.WriteLine("Ticket guardado Satisfactoriamente");
            }
            catch (Exception ex)
            {
                // Si hay algún error al leer o deserializar el archivo, lanzar una excepción con un mensaje de error
                throw new Exception("Error al guardar el ticket: " + ex.Message);
            }
        }
    }
}