using AutoMapper;
using BibliotecaAPI.DTO;
using BibliotecaAPI.Models;
using System.Linq;

namespace BibliotecaAPI.Services
{
    public interface ILibroServices
    {
        Response<LibroDTO> Get(int type = 0, int LibroId = 0);
        Response Post(LibroDTO LibroDTO);
        Response Put(LibroDTO LibroDTO);
        Response Delete(int LibroID);
    }
    public class LibroServices : ILibroServices
    {
        private readonly BibliotecaDbContext _dbContext;
        private readonly IMapper _mapper;

        public LibroServices(BibliotecaDbContext bibliotecaDbContext, IMapper mapper)
        {
            _dbContext = bibliotecaDbContext;
            _mapper = mapper;
        }

        public Response<LibroDTO> Get(int type = 0, int LibroId = 0)
        {
            var response = new Response<LibroDTO>();

            try
            {
                var Data = _dbContext.Libros.ToList();

                if (type == 1)
                {
                    Data = Data.Where(x => x.LibroId == LibroId).ToList();
                }
                var mapped = _mapper.Map<List<LibroDTO>>(Data);

                mapped.ForEach(x =>
                {
                    x.Autores = GetAutorLibro(x.LibroId).DataList.Select(x=>x.AutorId).ToList();
                    x.Categorias = GetCategoriaLibro(x.LibroId).DataList.Select(x => x.CategoriaId).ToList();
                });

                response.DataList = mapped;
            }
            catch (Exception ex)
            {
                response.Errors.Add("Ha ocurrido un error tratando de obtener los libros.");
            }


            return response;
        }

        public Response<LibroCategorium> GetCategoriaLibro(int LibroId = 0)
        {
            var response = new Response<LibroCategorium>();

            try
            {
                var Data = _dbContext.LibroCategoria.Where(x => x.LibroId == LibroId && x.Status == true).ToList();

                response.DataList = Data;
            }
            catch (Exception ex)
            {
                response.Errors.Add("Ha ocurrido un error tratando de obtener las categorias de los libros.");
            }


            return response;
        }

        public Response<LibroAutor> GetAutorLibro(int LibroId = 0)
        {
            var response = new Response<LibroAutor>();

            try
            {
                var Data = _dbContext.LibroAutors.Where(x=>x.LibroId == LibroId && x.Status == true).ToList();

                response.DataList = Data;
            }
            catch (Exception ex)
            {
                response.Errors.Add("Ha ocurrido un error tratando de obtener las categorias de los libros.");
            }


            return response;
        }

        public Response Post(LibroDTO LibroDTO)
        {
            var response = new Response();

            try
            {
                var data = _dbContext.Libros.Where(x => x.Titulo == LibroDTO.Titulo).ToList();

                if (data.Count == 0)
                {
                    var Libro = _mapper.Map<Libro>(LibroDTO);
                    _dbContext.Libros.Add(Libro);
                    _dbContext.SaveChanges();

                    var resultCategoria = LibroCategoria(Libro.LibroId, LibroDTO.Categorias);
                    var resultAutores = LibroAutor(Libro.LibroId, LibroDTO.Autores);

                    if (resultCategoria.Errors.Count() > 0)
                    {
                        response.Errors.Add(resultCategoria.Errors[0]);
                    }
                    if (resultAutores.Errors.Count() > 0)
                    {
                        response.Errors.Add(resultAutores.Errors[0]);
                    }

                }
                else
                {
                    response.Errors.Add("Ya existe un libro igual, por favor volver a intentarlo.");
                }
            }
            catch (Exception ex)
            {

                response.Errors.Add("Ha ocurrido un error tratando de insertar un libro.");
            }
            return response;
        }

        public Response Put(LibroDTO LibroDTO)
        {
            var response = new Response();

            try
            {
                var data = _dbContext.Libros.Find(LibroDTO.LibroId);
                _mapper.Map(LibroDTO, data);
                _dbContext.SaveChanges();

                var resultCategoria = LibroCategoria(LibroDTO.LibroId, LibroDTO.Categorias);
                var resultAutores = LibroAutor(LibroDTO.LibroId, LibroDTO.Autores);

                if (resultCategoria.Errors.Count() > 0)
                {
                    response.Errors.Add(resultCategoria.Errors[0]);
                }
                if (resultAutores.Errors.Count() > 0)
                {
                    response.Errors.Add(resultAutores.Errors[0]);
                }
            }
            catch (Exception ex)
            {
                response.Errors.Add("Ha ocurrido un error tratando de actualizar el libro.");
            }
            return response;
        }

        public Response Delete(int LibroID)
        {
            var response = new Response();

            try
            {
                var data = _dbContext.Libros.Find(LibroID);
                data.Status = false;

                _dbContext.Update(data);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                response.Errors.Add("Ha ocurrido un error tratando de eliminar el libro.");
            }
            return response;
        }

        public Response LibroCategoria(int LibroId, List<int?> Categorias)
        {

            var response = new Response();

            var existdata = _dbContext.LibroCategoria.Where(x => x.LibroId == LibroId).Select(x => x.CategoriaId).ToList();

            var soloEnExistdata = existdata.Except(Categorias).ToList();

            var soloEnListaComparacion = Categorias.Except(existdata).ToList();

            var valoresCoincidentes = existdata.Intersect(Categorias).ToList();

            try
            {
                foreach (var item in soloEnListaComparacion)
                {
                    var mapped = new LibroCategorium();
                    mapped.LibroId = LibroId;
                    mapped.CategoriaId = item;
                    mapped.Status = true;
                    _dbContext.LibroCategoria.Add(mapped);
                    _dbContext.SaveChanges();
                }

                foreach (var item in soloEnExistdata)
                {
                    var data = _dbContext.LibroCategoria.Where(x => x.LibroId == LibroId && x.CategoriaId == item).FirstOrDefault();
                    data.Status = false;
                    _dbContext.SaveChanges();
                }

                foreach (var item in valoresCoincidentes)
                {
                    var data = _dbContext.LibroCategoria.Where(x => x.LibroId == LibroId && x.CategoriaId == item).FirstOrDefault();
                    data.Status = true;
                    _dbContext.SaveChanges();
                }

            }
            catch (Exception ex)
            {

                response.Errors.Add("Ha ocurrido un error tratando de insertar/actualizar una relacion de libro y categoria.");
            }
            return response;
        }

        public Response LibroAutor(int LibroId, List<int?> Autores)
        {
            var response = new Response();

            var existdata = _dbContext.LibroAutors.Where(x => x.LibroId == LibroId).Select(x => x.AutorId).ToList();

            var soloEnExistdata = existdata.Except(Autores).ToList();

            var soloEnListaComparacion = Autores.Except(existdata).ToList();

            var valoresCoincidentes = existdata.Intersect(Autores).ToList();

            try
            {
                foreach (var item in soloEnListaComparacion)
                {
                    var mapped = new LibroAutor();
                    mapped.LibroId = LibroId;
                    mapped.AutorId = item;
                    mapped.Status = true;
                    _dbContext.LibroAutors.Add(mapped);
                    _dbContext.SaveChanges();
                }

                foreach (var item in soloEnExistdata)
                {
                    var data = _dbContext.LibroAutors.Where(x => x.LibroId == LibroId && x.AutorId == item).FirstOrDefault();
                    data.Status = false;
                    _dbContext.SaveChanges();
                }

                foreach (var item in valoresCoincidentes)
                {
                    var data = _dbContext.LibroAutors.Where(x => x.LibroId == LibroId && x.AutorId == item).FirstOrDefault();
                    data.Status = true;
                    _dbContext.SaveChanges();
                }

            }
            catch (Exception ex)
            {

                response.Errors.Add("Ha ocurrido un error tratando de insertar/actualizar una relacion de libro y autor.");
            }
            return response;
        }
    }
}

