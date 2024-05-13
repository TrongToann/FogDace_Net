using Application.Data;
using AutoMapper;
using Contract.Abstraction.Message;
using Contract.Abstraction.Shared;
using Contract.DTOs.PetHealthProfileDTO;
using Domain.Entities;
using static Contract.Service.PetHealthProfile.Command;

namespace Application.Features.V1.Command.PetHealthProfile
{
    public class CreatePetHealthProfileCommandHandler : ICommandHandler<CreatePetHealthProfile>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePetHealthProfileCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result> Handle(CreatePetHealthProfile request, CancellationToken cancellationToken)
        {
            Result.CheckExist(await _unitOfWork.GetRepository<Domain.Entities.Pet, Guid>()
                .FindByIdAsync(request.CreatePetHealthProfileDTO.Pet_id));

            var petHealthProfile = _mapper.Map<Domain.Entities.PetHealthProfile>(request.CreatePetHealthProfileDTO);

            _unitOfWork.GetRepository<Domain.Entities.PetHealthProfile, Guid>().Add(petHealthProfile);

            var affected = await _unitOfWork.SaveChangesAsync(request.Account_id);
            if (affected < 1) return Result.Failure(Error.InternalServerValue);

            await InsertAllPetHealthDetail(request.CreatePetHealthProfileDTO, petHealthProfile.Id, 
                cancellationToken, request.Account_id);

            return Result.Success();
        }
        private void InsertTiemPhong(CreatePetHealthProfileDTO request, Guid PetHealthProfile_id)
        {
            foreach(var tiemphong in request.InputTiemPhong)
            {
                _unitOfWork.GetRepository<TiemPhong, Guid>().Add(new TiemPhong
                {
                    PetHealthProfile_id = PetHealthProfile_id,
                    Date = tiemphong.Date,
                    Note = tiemphong.Note,
                });
            }
        }
        private void InsertTinhCach(CreatePetHealthProfileDTO request, Guid PetHealthProfile_id)
        {
            foreach (var tinhcach in request.InputTinhCach)
            {
                _unitOfWork.GetRepository<TinhCach, Guid>().Add(new TinhCach
                {
                    PetHealthProfile_id = PetHealthProfile_id,
                    Date = tinhcach.Date,
                    Note = tinhcach.Note,
                });
            }
        }
        private void InsertTinhTrangSK(CreatePetHealthProfileDTO request, Guid PetHealthProfile_id)
        {
            foreach (var tinhtrang in request.InputTinhTrangSK)
            {
                _unitOfWork.GetRepository<TinhTrangSK, Guid>().Add(new TinhTrangSK
                {
                    PetHealthProfile_id = PetHealthProfile_id,
                    Date = tinhtrang.Date,
                    Note = tinhtrang.Note,
                });
            }
        }
        private void InsertDinhDuong(CreatePetHealthProfileDTO request, Guid PetHealthProfile_id)
        {
            foreach (var dinhduong in request.InputDinhDuong)
            {
                _unitOfWork.GetRepository<DinhDuong, Guid>().Add(new DinhDuong
                {
                    PetHealthProfile_id = PetHealthProfile_id,
                    Note = dinhduong.Note,
                });
            }
        }
        private void InsertXoGiun(CreatePetHealthProfileDTO request, Guid PetHealthProfile_id)
        {
            foreach (var tiemphong in request.InputXoGiun)
            {
                _unitOfWork.GetRepository<XoGiun, Guid>().Add(new XoGiun
                {
                    PetHealthProfile_id = PetHealthProfile_id,
                    Date = tiemphong.Date,
                });
            }
        }
        private async Task InsertAllPetHealthDetail
            (CreatePetHealthProfileDTO request, Guid PetHealthProfile_id, CancellationToken cancellationToken, Guid Account_id)
        {
            var taskTiemPhong = Task.Run(() => InsertTiemPhong(request, PetHealthProfile_id), cancellationToken);
            var taskTinhCach = Task.Run(() => InsertTinhCach(request, PetHealthProfile_id), cancellationToken);
            var taskTinhTrangSK = Task.Run(() => InsertTinhTrangSK(request, PetHealthProfile_id), cancellationToken);
            var taskXoGiun = Task.Run(() => InsertXoGiun(request, PetHealthProfile_id), cancellationToken);
            var taskDinhDuong = Task.Run(() => InsertDinhDuong(request, PetHealthProfile_id), cancellationToken);
            await Task.WhenAll(taskTiemPhong, taskTinhCach, taskTinhTrangSK, taskXoGiun);

            await _unitOfWork.SaveChangesAsync(Account_id);
        }
    }
}
